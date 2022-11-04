## <b>UC G.2.3 - Editar uma Entrega</b>
</br>

### <b>1. Engenharia de Requesitos</b>
</br>

#### <b>1.A. Formato Completo </b>
</br>

<b>Ator Principal</b>
<p>&ensp;&ensp;&ensp;&ensp;Gestor de Armazém</p>
</br>

<b>Atores Interessados e respetivos interesses</b>
<p>&ensp;&ensp;&ensp;&ensp;<b>Gestor de Armazém:</b> pretende editar uma entrega.</p>
<br>

<b>Pré-Condições</b>
<p>&ensp;&ensp;&ensp;&ensp;É necessário existirem entregas registadas.</p>
</br>

<b>Pós-Condições</b>
<p>&ensp;&ensp;&ensp;&ensp;N/A.</p>
</br>

<b>Cenário Principal</b>
<ol>
    <li>O Gestor de Armazém inicia o processo de editar uma entrega.</li>
    <li>O Sistema apresenta ao gestor as entregas disponíveis e solicita que selecione a que pretende alterar.</li>
        <li>O Gestor de Armazém seleciona a entrega que pretende alterar.</li>
    <li>O Sistema solicita os dados que pretende alterar.</li>
        <li>O Gestor de Armazém inseres os dados.</li>
    <li>O Sistemas apresenta os dados e solicita confirmação.</li>
        <li>O Gestor de Armazám confirma os dados previamente inseridos.</li>
    <li>O Sistemas regista e persiste a entrega atualizada e indica o sucesso de operação.</li>

</ol>
</br>

<b>Cenários Alternativos</b>
<p>&ensp;&ensp;&ensp;&ensp;*a. O Gestor de Armazém cancela a operação;</p>
<p>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;O caso de uso termina;</p>
</br>
<p>&ensp;&ensp;&ensp;&ensp;4.a. O Gestor de Armazém modifica o armazém original da entrega para um novo, e este não se encontra resgistado.</p>

> <p>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;1. O Sistema avisa que o armazem não existe e pede um de novo.</p>
><p>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;2.a. O Gestor de Armazém não selecina outro armazém;</p>
><p>&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;2.b. O caso de uso termina e não são guardadas as alterações;</p>
</br>
<b>Requerimentos Especiais</b>
<p>&ensp;&ensp;&ensp;&ensp;N/A</p>
</br>

<b>Lista de Variações de Tecnologia</b>
<p>&ensp;&ensp;&ensp;&ensp;N/A</p>
</br>


### <b>2. Design</b>
</br>

#### <b>2.A. Rationale</b>
*TODO*
</br>

#### <b>2.B. Sistematização</b>
</br>

<p>Do Rationale, as seguintes Classes Conceptuais são promovidas a Classes de Software:</p>

<ul>
    <li>Entrega;</li>
</ul>
</br>

<p>Outras Classes de Software identificadas:</p>
<ul>
    <li>EntregaController;</li>
    <li>EntregaService;</li>
    <li>EntregaRepo;</li>
    <li>EntregaMapper;</li>
    <li>EntregaDTO;</li>

</ul>
</br>

#### <b>2.C. Diagramas</b>
</br>

<b>Diagrama Nível 1</b>

![Diagrama Nível 1](./N%C3%ADvel%20%231/N%C3%ADvel%20%231-Vista%20de%20Processo%20UC%20G.2.3.png)

<b>Diagrama Nível 2</b>

![Diagrama Nível 2](./N%C3%ADvel%20%232/N%C3%ADvel%20%232-Vista%20Processo%20UC%20G.2.3.png)

<b>Diagrama Nível 3</b>

![Diagrama Nível 3](./N%C3%ADvel%20%233/N%C3%ADvel%233%20-%20Vista%20de%20Processo%20UC%20G.2.3.png)
</br>
</br>

#### <b>2.D. Test Planning</b>
</br>

<p>This section contains primary Unit Tests developped in order to affer the satisfaction of the User Stories requisites;</p>
</br>

| Tested Class | Test Objective | <div style="width:450px">Implementation</div> |
|:--------------|:-------------------------|:------------------------|
||||
*TODO*