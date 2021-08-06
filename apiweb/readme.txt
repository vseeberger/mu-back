# Crio a estrutura de pastas
* Models
	* Crio os modelos de dados
* Data
	* DataContext.cs

# Executar a criação das migrations
> Devo criar uma primeira versão do script
``` bash
- Listo os comandos do EF
get-help entityframeworkcore

- Adicionar um novo 'script' de migração
Add-Migration NOME_DA_MIGRATION

- Excluir a migration
Remove-Migration

- Atualiza o banco de dados com a migration específica
Update-Database
```