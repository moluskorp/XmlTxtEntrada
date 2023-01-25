using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace XmlTxt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        string GetProdLine(TNFeInfNFeDetProd prod)
        {
            return $"D.A|{prod.cProd}|{prod.cEAN}|{prod.xProd}|{prod.NCM}|{prod.CFOP}|" +
                $"{prod.uCom}|{prod.qCom}|{prod.vUnCom}|{prod.vProd}|{prod.cEANTrib}|{prod.uTrib}|{prod.qTrib}|{prod.vUnTrib}|{prod.indTot.ToString().Replace("Item", "")}";
        }

        string GetEnderEmitLine(TNFeInfNFeEmit emit)
        {
            return $"B.A|{emit.enderEmit.xLgr}|{emit.enderEmit.nro}|{emit.enderEmit.xCpl}|{emit.enderEmit.xBairro}|{emit.enderEmit.cMun}|" +
                            $"{emit.enderEmit.xMun}|{emit.enderEmit.UF}|{emit.enderEmit.CEP}|{emit.enderEmit.cPais.ToString().Replace("Item", "")}|{emit.enderEmit.xPais}|{emit.enderEmit.fone}";
        }

        string GetEnderDestLine(TNFeInfNFeDest dest)
        {
            return $"C.A|{dest.enderDest.xLgr}|{dest.enderDest.nro}|{dest.enderDest.xCpl}|{dest.enderDest.xBairro}|" +
                $"{dest.enderDest.cMun}|{dest.enderDest.xMun}|{dest.enderDest.UF}|{dest.enderDest.CEP}|{dest.enderDest.cPais.ToString().Replace("Item", "")}|" +
                $"{dest.enderDest.xPais}|{dest.enderDest.fone}";
        }

        string GetIdeLine(TNFeInfNFeIde ide)
        {
            return $"A|{ide.cUF.ToString().Replace("Item", "")}|{ide.cNF}|{ide.natOp}|{ide.mod.ToString().Replace("Item", "")}|{ide.serie.ToString().Replace("Item", "")}|" +
                $"{ide.nNF}|{ide.dhEmi}|" +
                            $"{ide.dhSaiEnt}|{ide.tpNF.ToString().Replace("Item", "")}|{ide.idDest.ToString().Replace("Item", "")}|" +
                            $"{ide.cMunFG}|{ide.tpImp.ToString().Replace("Item", "")}|" +
                            $"{ide.tpEmis.ToString().Replace("Item", "")}|{ide.cDV.ToString().Replace("Item", "")}|{ide.tpAmb.ToString().Replace("Item", "")}|{ide.finNFe.ToString().Replace("Item", "")}|" +
                            $"{ide.indFinal.ToString().Replace("Item", "")}|{ide.indPres.ToString().Replace("Item", "")}|{ide.procEmi.ToString().Replace("Item", "")}|" +
                            $"{ide.verProc.ToString().Replace("Item", "")}";
        }

        string GetEmitLine(TNFeInfNFeEmit emit)
        {
            return $"B|{emit.Item}|{emit.xNome}|{emit.xFant}|{emit.IE}|{emit.CRT.ToString().Replace("Item", "")}";
        }

        string GetDestLine(TNFeInfNFeDest dest)
        {
            return $"C|{dest.Item}|{dest.xNome}|{dest.indIEDest.ToString().Replace("Item", "")}|{dest.IE}|{dest.email}";
        }

        string getStream(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (!String.IsNullOrEmpty(fbd.SelectedPath))
            {
                txtXmlLocation.Text = fbd.SelectedPath;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (!String.IsNullOrEmpty(fbd.SelectedPath))
            {
                txtBkp.Text = fbd.SelectedPath;
            }
        }

        private void btnSelectTxtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (!String.IsNullOrEmpty(fbd.SelectedPath))
            {
                txtTxt.Text = fbd.SelectedPath;
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtTxt.Text) || String.IsNullOrEmpty(txtBkp.Text) || String.IsNullOrEmpty(txtXmlLocation.Text))
            {
                MessageBox.Show("Campo não preenchido", "Campo não preenchido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(txtXmlLocation.Text);
            List<Files> files = new List<Files>();
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.ToUpper() == ".XML")
                {
                    Files fileXml = new Files(file.FullName, file.Name);
                    files.Add(fileXml);
                }
            }
            string pathTxt = $@"{txtTxt.Text}\nota.txt";
            using (StreamWriter sw = new StreamWriter(pathTxt))
            {

                foreach (Files file in files)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TNfeProc));

                    TNfeProc tNfe;
                    using (StreamReader sr = new StreamReader(file.FullName))
                    {
                        tNfe = TNfeProc.GetNfeProc(sr.ReadToEnd());
                    }
                    TNFeInfNFeIde ide = tNfe.NFe.infNFe.ide;
                    TNFeInfNFeEmit emit = tNfe.NFe.infNFe.emit;
                    TNFeInfNFeDest dest = tNfe.NFe.infNFe.dest;
                    TNFeInfNFeTotal totalNode = tNfe.NFe.infNFe.total;
                    TNFeInfNFeTotalICMSTot total = totalNode.ICMSTot;
                    TNFeInfNFeTransp transp = tNfe.NFe.infNFe.transp;
                    string[] dhEmiSplit = ide.dhEmi.Split('-');
                    string yearEmi = dhEmiSplit[0];
                    string monthEmi = dhEmiSplit[1];
                    string dayEmi = dhEmiSplit[2];
                    string cnpjEmi = emit.Item;

                    sw.WriteLine(GetIdeLine(ide));
                    sw.WriteLine(GetEmitLine(emit));
                    sw.WriteLine(GetEnderEmitLine(emit));
                    sw.WriteLine(GetDestLine(dest));
                    sw.WriteLine(GetEnderDestLine(dest));



                    foreach (TNFeInfNFeDet det in tNfe.NFe.infNFe.det)
                    {

                        sw.WriteLine($"D|{det.nItem}");
                        TNFeInfNFeDetProd prod = det.prod;
                        sw.WriteLine(GetProdLine(prod));
                        TNFeInfNFeDetImposto imposto = det.imposto;
                        dynamic items = imposto.Items[0];
                        dynamic item = items.Item;
                        dynamic cofinsItems = imposto.COFINS;
                        dynamic pisItems = imposto.PIS;
                        var myType = item.GetType().ToString();
                        var myTypeCofins = imposto.COFINS.Item.GetType().ToString();
                        var myTypePis = imposto.PIS.Item.GetType().ToString();

                        #region ICMS
                        if (myType == "TNFeInfNFeDetImpostoICMSICMS00")
                        {
                            TNFeInfNFeDetImpostoICMSICMS00 ICMS = items.Item;
                            sw.WriteLine($"ICMS00|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|" +
                                $"{ICMS.pFCP}|{ICMS.pICMS}|{ICMS.vBC}|{ICMS.vFCP}|{ICMS.vICMS}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS10")
                        {
                            TNFeInfNFeDetImpostoICMSICMS10 ICMS = items.Item;
                            sw.WriteLine($"ICMS10|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|" +
                                $"{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCP}|{ICMS.pFCPST}|{ICMS.pICMS}|{ICMS.pICMSST}|{ICMS.pMVAST}|" +
                                $"{ICMS.pRedBCST}|{ICMS.vBC}|{ICMS.vBCFCP}|{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vFCP}|{ICMS.vFCPST}|{ICMS.vICMS}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS20")
                        {
                            TNFeInfNFeDetImpostoICMSICMS20 ICMS = items.Item;
                            sw.WriteLine($"ICMS20|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|" +
                                $"{ICMS.motDesICMS.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCP}|{ICMS.pICMS}|{ICMS.pRedBC}|" +
                                $"{ICMS.vBC}|{ICMS.vBCFCP}|{ICMS.vFCP}|{ICMS.vICMS}|{ICMS.vICMSDeson}");

                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS30")
                        {
                            TNFeInfNFeDetImpostoICMSICMS30 ICMS = items.Item;
                            sw.WriteLine($"ICMS30|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|{ICMS.motDesICMS.ToString().Replace("Item", "")}|" +
                                $"{ICMS.orig.ToString().Replace("Item", "")}|" +
                                $"{ICMS.pFCPST}|{ICMS.pICMSST}|{ICMS.pMVAST}|{ICMS.pRedBCST}|{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vFCPST}|{ICMS.vICMSDeson}|{ICMS.vICMSST}");


                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS40")
                        {
                            TNFeInfNFeDetImpostoICMSICMS40 ICMS = items.Item;
                            sw.WriteLine($"ICMS40|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.vICMSDeson}|{ICMS.motDesICMS.ToString().Replace("Item", "")}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS51")
                        {
                            TNFeInfNFeDetImpostoICMSICMS51 ICMS = items.Item;
                            sw.WriteLine($"ICMS51|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCSpecified.ToString().Replace("Item", "")}|" +
                                $"{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pDif}|{ICMS.pFCP}|{ICMS.pICMS}|{ICMS.pRedBC}|{ICMS.vBC}|{ICMS.vBCFCP}|{ICMS.vFCP}|" +
                                $"{ICMS.vICMS}|{ICMS.vICMSDif}|{ICMS.vICMSOp}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS60")
                        {
                            TNFeInfNFeDetImpostoICMSICMS60 ICMS = items.Item;
                            sw.WriteLine($"ICMS60|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCPSTRet}|" +
                                $"{ICMS.pICMSEfet}|{ICMS.pRedBCEfet}|{ICMS.pST}|{ICMS.vBCEfet}|{ICMS.vBCFCPSTRet}|" +
                                $"{ICMS.vBCSTRet}|{ICMS.vFCPSTRet}|{ICMS.vICMSEfet}|{ICMS.vICMSSTRet}|{ICMS.vICMSSubstituto}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS70")
                        {
                            TNFeInfNFeDetImpostoICMSICMS70 ICMS = items.Item;
                            sw.WriteLine($"ICMS70|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|" +
                                $"{ICMS.motDesICMS.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCP}|{ICMS.pFCPST}|{ICMS.pICMS}|" +
                                $"{ICMS.pICMSST}|{ICMS.pMVAST}|{ICMS.pRedBC}|{ICMS.pRedBCST}|{ICMS.vBC}|{ICMS.vBCFCP}|{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vFCP}|{ICMS.vFCPST}|" +
                                $"{ICMS.vICMS}|{ICMS.vICMSDeson}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMS90")
                        {
                            TNFeInfNFeDetImpostoICMSICMS90 ICMS = items.Item;
                            sw.WriteLine($"ICMS90|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|" +
                                $"{ICMS.motDesICMS.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCP}|{ICMS.pFCPST}|{ICMS.pICMS}|{ICMS.pICMSST}|" +
                                $"{ICMS.pMVAST}|{ICMS.pRedBC}|{ICMS.pRedBCST}|{ICMS.vBC}|{ICMS.vBCFCP}|{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vFCP}|{ICMS.vFCPST}|{ICMS.vICMS}|{ICMS.vICMSDeson}|" +
                                $"{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSPart")
                        {
                            TNFeInfNFeDetImpostoICMSICMSPart ICMS = items.Item;
                            sw.WriteLine($"ICMSPART|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|" +
                                $"{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pBCOp}|{ICMS.pICMS}|{ICMS.pICMSST}|{ICMS.pMVAST}|" +
                                $"{ICMS.pRedBC}|{ICMS.pRedBCST}|{ICMS.UFST}|{ICMS.vBC}|{ICMS.vBCST}|{ICMS.vICMS}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN101")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN101 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN101|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pCredSN}|{ICMS.vCredICMSSN}");

                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN102")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN102 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN102|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN201")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN201 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN201|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|" +
                                $"{ICMS.pCredSN}|{ICMS.pFCPST}|{ICMS.pICMSST}|{ICMS.pMVAST}|{ICMS.pRedBCST}|" +
                                $"{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vCredICMSSN}|{ICMS.vFCPST}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN202")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN202 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN202|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|" +
                                $"{ICMS.pFCPST}|{ICMS.pICMSST}|{ICMS.pMVAST}|{ICMS.pRedBCST}|{ICMS.vBCFCPST}|{ICMS.vBCST}|" +
                                $"{ICMS.vFCPST}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN500")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN500 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN500|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCPSTRet}|{ICMS.pICMSEfet}|{ICMS.pRedBCEfet}|" +
                                $"{ICMS.pST}|{ICMS.vBCEfet}|{ICMS.vBCFCPSTRet}|" +
                                $"{ICMS.vBCSTRet}|{ICMS.vFCPSTRet}|{ICMS.vICMSEfet}|{ICMS.vICMSSTRet}|{ICMS.vICMSSubstituto}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSSN900")
                        {
                            TNFeInfNFeDetImpostoICMSICMSSN900 ICMS = items.Item;
                            sw.WriteLine($"ICMSSN900|{ICMS.CSOSN.ToString().Replace("Item", "")}|{ICMS.modBC.ToString().Replace("Item", "")}|{ICMS.modBCST.ToString().Replace("Item", "")}|" +
                                $"{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pCredSN}|{ICMS.pFCPST}|{ICMS.pICMS}|{ICMS.pICMSST}|{ICMS.pMVAST}|" +
                                $"{ICMS.pRedBC}|{ICMS.pRedBCST}|{ICMS.vBC}|{ICMS.vBCFCPST}|{ICMS.vBCST}|{ICMS.vCredICMSSN}|{ICMS.vFCPST}|{ICMS.vICMS}|{ICMS.vICMSST}");
                        }
                        else if (myType == "TNFeInfNFeDetImpostoICMSICMSST")
                        {
                            TNFeInfNFeDetImpostoICMSICMSST ICMS = items.Item;
                            sw.WriteLine($"ICMSST|{ICMS.CST.ToString().Replace("Item", "")}|{ICMS.orig.ToString().Replace("Item", "")}|{ICMS.pFCPSTRet}|{ICMS.pICMSEfet}|{ICMS.pRedBCEfet}|" +
                                $"{ICMS.pST}|{ICMS.vBCEfet}|{ICMS.vBCFCPSTRet}|" +
                                $"{ICMS.vBCSTDest}|{ICMS.vBCSTRet}|{ICMS.vFCPSTRet}|{ICMS.vICMSEfet}|{ICMS.vICMSSTDest}|{ICMS.vICMSSTRet}|{ICMS.vICMSSubstituto}");
                        }
                        TNFeInfNFeDetImpostoICMSUFDest ICMSDest = imposto.ICMSUFDest;
                        if (ICMSDest != null)
                        {
                            sw.WriteLine($"ICMSDest|{ICMSDest.pFCPUFDest}|{ICMSDest.pICMSInter}|{ICMSDest.pICMSInterPart}|{ICMSDest.pICMSUFDest}|{ICMSDest.vBCFCPUFDest}|" +
    $"{ICMSDest.vBCUFDest}|{ICMSDest.vFCPUFDest}|{ICMSDest.vICMSUFDest}|{ICMSDest.vICMSUFRemet}");
                        }
                        #endregion
                        #region COFINS
                        if (myTypeCofins == "TNFeInfNFeDetImpostoCOFINSCOFINSAliq")
                        {
                            TNFeInfNFeDetImpostoCOFINSCOFINSAliq cofins = cofinsItems.Item;
                            sw.WriteLine($"COFINSAl|{cofins.CST.ToString().Replace("Item", "")}|{cofins.pCOFINS}|{cofins.vBC}|{cofins.vCOFINS}");
                        }
                        else if (myTypeCofins == "TNFeInfNFeDetImpostoCOFINSCOFINSNT")
                        {
                            TNFeInfNFeDetImpostoCOFINSCOFINSNT cofins = cofinsItems.Item;
                            sw.WriteLine($"COFINSNT|{cofins.CST.ToString().Replace("Item", "")}");
                        }

                        else if (myTypeCofins == "TNFeInfNFeDetImpostoCOFINSCOFINSOutr")
                        {
                            TNFeInfNFeDetImpostoCOFINSCOFINSOutr cofins = cofinsItems.Item;
                            sw.WriteLine($"COFINSOu|{cofins.CST.ToString().Replace("Item", "")}|{cofins.vCOFINS}");
                        }
                        else if (myTypeCofins == "TNFeInfNFeDetImpostoCOFINSCOFINSQtde")
                        {
                            TNFeInfNFeDetImpostoCOFINSCOFINSQtde cofins = cofinsItems.Item;
                            sw.WriteLine($"COFINSQt|{cofins.CST.ToString().Replace("Item", "")}|{cofins.qBCProd}|{cofins.vAliqProd}|{cofins.vCOFINS}");
                        }
                        if (imposto.COFINSST != null)
                        {
                            sw.WriteLine($"COFINSST|{imposto.COFINSST.vCOFINS}");
                        }
                        #endregion
                        #region PIS
                        if (myTypePis == "TNFeInfNFeDetImpostoPISPISAliq")
                        {
                            TNFeInfNFeDetImpostoPISPISAliq pis = pisItems.Item;
                            sw.WriteLine($"PISAl|{pis.CST.ToString().Replace("Item", "")}|{pis.pPIS}|{pis.vBC}|{pis.vPIS}");
                        }

                        else if (myTypePis == "TNFeInfNFeDetImpostoPISPISNT")
                        {
                            TNFeInfNFeDetImpostoPISPISNT pis = pisItems.Item;
                            sw.WriteLine($"PISNT|{pis.CST.ToString().Replace("Item", "")}");
                        }

                        else if (myTypePis == "TNFeInfNFeDetImpostoPISPISOutr")
                        {
                            TNFeInfNFeDetImpostoPISPISOutr pis = pisItems.Item;
                            sw.WriteLine($"PISOu|{pis.CST.ToString().Replace("Item", "")}|{pis.vPIS}");
                        }

                        else if (myTypePis == "TNFeInfNFeDetImpostoPISPISQtde")
                        {
                            TNFeInfNFeDetImpostoPISPISQtde pis = pisItems.Item;
                            sw.WriteLine($"PISQt|{pis.CST.ToString().Replace("Item", "")}|{pis.qBCProd}|{pis.vAliqProd}|{pis.vPIS}");
                        }
                        if (imposto.PISST != null)
                        {
                            sw.WriteLine($"PISST|{imposto.PISST.vPIS}");
                        }
                        #endregion
                        sw.WriteLine($"vTotTrib|{imposto.vTotTrib}");
                    }
                    sw.WriteLine($"E|{total.vBC}|{total.vICMS}|{total.vICMSDeson}|{total.vFCP}|{total.vBCST}|{total.vST}|{total.vFCPST}|{total.vFCPSTRet}|{total.vProd}|{total.vFrete}|" +
                        $"{total.vSeg}|{total.vDesc}|{total.vII}|{total.vIPI}|{total.vIPIDevol}|{total.vPIS}|{total.vCOFINS}|{total.vOutro}|{total.vNF}|{total.vTotTrib}");
                    sw.WriteLine($"F|{transp.modFrete.ToString().Replace("Item", "")}");
                    if (transp.transporta != null)
                    {
                        TNFeInfNFeTranspTransporta transporta = transp.transporta;
                        sw.WriteLine($"F.A|{transporta.IE}|{transporta.Item}|{transporta.UF}|{transporta.xEnder}|{transporta.xMun}|{transporta.xNome}");
                    }
                    string directoryBkp = $@"{txtBkp.Text}\{yearEmi}\{monthEmi}\{cnpjEmi}";
                    if (!Directory.Exists(directoryBkp))
                    {
                        Directory.CreateDirectory(directoryBkp);
                    }
                    File.Move(file.FullName, $@"{directoryBkp}\{file.Name}");
                    continue;
                }
            }
            MessageBox.Show("Concluído","Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}


    

