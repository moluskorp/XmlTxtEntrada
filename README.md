# Projeto C# Windows Form - Leitor de arquivos XML

Este projeto é uma aplicação de Windows Form que lê arquivos XML de uma pasta específica, junta-os em um arquivo de texto separado por "|" e move os arquivos lidos para uma pasta de backup organizada por ano, mês e CNPJ.

## Recursos

- Interface gráfica fácil de usar
- Seleção de pastas através do BrowseFileDialog
- Leitura de arquivos XML de uma pasta específica
- Juntar arquivos XML lidos em um arquivo de texto separado por "|"
- Backup dos arquivos XML lidos organizado por ano, mês e CNPJ


## Como usar

1. Abra o projeto no Visual Studio
2. Compile e execute o projeto
3. Na tela inicial, selecione a pasta onde os arquivos XML se encontram usando o botão
4. Selecione a pasta de backup para os arquivos XML lidos usando o botão
5. Selecione a pasta onde o arquivo de texto será salvo usando o botão
6. Clique no botão "Gerar" para iniciar o processo de leitura e backup dos arquivos XML
7. Verifique a pasta de backup e a pasta do arquivo de texto para verificar se os arquivos foram movidos e processados corretamente.

## Observações

- Certifique-se de que as pastas selecionadas contenham arquivos XML válidos antes de clicar no botão "Gerar"
- Certifique-se de que as pastas de backup e do arquivo de texto tenham permissão de escrita antes de iniciar o - processo.
- Consulte o arquivo campos.txt que contém o layout de saída
- O projeto foi desenvolvido e testado com o .NET Framework 4.8, certifique-se de que sua versão do Visual Studio e do Framework estejam atualizadas.

