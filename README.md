# DotNet Core API-AD-Group #

API em DotNet Core com autenticação por grupos do AD do windows. 

<p>Essa é uma API simples porém com uma funcionalidade <b>ENORME</b>, além de conseguir utiliza-lá 
para se conectar com o AD, ela também permite fazer uma autenticação dentro de um grupo específico do AD, 
trazendo várias possíbilidades, como o bloqueio de algum site interno de uma empresa
para somente a usuários de um grupo específico de dentro da empresa.</p>

Para poder utilizar essa API deve-se adicionar o seguinte pacote:

<h3>System.DirectoryServices.AccountManagement</h3>

<p>Para adicionar esse pacote, rode o seguinte comando dentro da pasta <b>myapp</b>:
dotnet add package System.DirectoryServices.AccountManagement --version 4.7.0;</p>

Caso dê algum problema na hora de testar, tente fechar e abrir novamente a sua IDE ou tente instalar novamente,
se o erro persistir, por favor entre em contato comigo no meu e-mail: gustavoscarpim@gmail.com.

<h1>Desenvolvido por Gustavo Scarpim</h1>
