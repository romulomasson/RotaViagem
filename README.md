## Projeto Rota Viagem para apresentar padrão de desenvolvimento

Feito em .netCore 7.0, Angular +18


## Rodando o projeto

Run yarn install

Run yarn start

## Rodando o projeto
Executar a API que vai subir na `http://localhost:5000/`.

## Banco de Dados

Foi utilizado um banco SQL local 
CREATE TABLE Rota
(
	RotaId INT IDENTITY(1,1)
	,Descricao VARCHAR(150)
	,Custo DECIMAL(14,2)
	,Origem VARCHAR(3)
	,Destino VARCHAR(3)
	,DataCadastro DATETIME
	,UsuarioCadastro INT
	, DataAlteracao DATETIME
	, UsuarioALteracao INT
	, Ativo BIT
)


