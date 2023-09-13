# algo_mat
Enunciado:
<p><strong>Projeto 3</strong></p>
<p>Considere um software, cujo desenvolvimento está sob sua responsabilidade, para controle de frotas de caminhões de entregas.</p>
<ol>
<li>Implemente uma estrutura de dados que reflita a organização dos volumes das caçambas dos caminhões para a entrega. Lembre-se de que os volumes que serão entregues primeiro ficarão no topo. Deve ser possível:<ol style="list-style-type: lower-alpha;">
<li>Inserir volumes;</li>
<li>Remover volumes;</li>
<li>Verificar qual volume está no topo.</li>
</ol></li>
<li>Implemente uma estrutura de dados que reflita a organização dos pontos de entrega que os caminhões visitarão, em ordem. Deve ser possível:<ol style="list-style-type: lower-alpha;">
<li>Inserir pontos de entrega;</li>
<li>Remover pontos de entrega;</li>
<li>Verificar os dados de um ponto.</li>
</ol></li>
<li>Implemente uma estrutura de dados que possibilite armazenar a lista de itens a serem entregues por cada ponto de entrega. Deve ser possível:<ol style="list-style-type: lower-alpha;">
<li>Inserir item à lista de entrega;</li>
<li>Remover item da lista de entrega;</li>
<li>Consultar um item da lista de entrega.</li>
</ol></li>
<li>Implemente uma estrutura de dados que possibilite armazenar um conjunto de caminhões, do tipo Caminhao. Deve ser possível:<ol style="list-style-type: lower-alpha;">
<li>Inserir caminhão;</li>
<li>Remover caminhão;</li>
<li>Consultar um caminhão, listando seus pontos de entrega e itens a serem entregues por ponto de entrega.</li>
</ol></li>
</ol>
<p>Caminhao é uma classe que contém os atributos:</p>
<ul>
<li>Placa;</li>
<li>Conjunto de pontos de entrega, do tipo Local;</li>
<li>Conjunto de itens, do tipo ItemEntrega, em sua caçamba.</li>
</ul>
<p>Um Local é uma classe que contém os atributos:</p>
<ul>
<li>Identificador;</li>
<li>Nome;</li>
<li>Conjunto de itens, do tipo ItemEntrega, que devem ser entregues.</li>
</ul>
<p>Um ItemEntrega é uma classe que contém os atributos:</p>
<ul>
<li>Identificador;</li>
<li>Nome.</li>
</ul>
<p>Funcionamento do programa:</p>
<ul>
<li>Inicialize as estruturas dos conjuntos de caminhões, itens de entrega e locais.</li>
<li>Ao ser iniciado, o programa deve exibir o seguinte menu:</li>
</ul>
<p style="margin-left: 60px;">[1] Inserir ponto de entrega;<br>[2] Inserir item de entrega;<br>[3] Inserir caminhão;<br>[4] Associar item a ponto de entrega;<br>[5] Associar ponto de entrega a caminhão;<br>[6] Realizar entregas;<br>[0] Sair.</p>
<p>Requisitos de cada item de menu a seguir:</p>
<p style="padding-left: 30px;">[1]Deve ser criado um objeto do tipo Local;<br>[2]Deve ser criado um objeto do tipo ItemEntrega;<br>[3]Deve ser criado um objeto do tipo Caminhao;<br>[4]Solicita um item de entrega já cadastrado e um local já cadastrado, e associa o item ao local;<br>[5]Solicita um ponto de entrega já cadastrado e um caminhão já cadastrado e associa o local ao caminhão. O local será o próximo ponto da lista dos que será visitado pelo caminhão;</p>
<p style="padding-left: 30px;">[6]Desencadeia o algoritmo que realiza as entregas:</p>
<ul>
<li>Empilha os itens que serão entregues pelo caminhão;</li>
<li>Caso haja pontos de entrega cadastrados sem caminhão associado:<ol>
<li>Para cada ponto de entrega P, verifica que caminhão C possui menos pontos de entrega, e aloca P a C.</li>
<li>Caso haja mais de um caminhão com o mesmo número de pontos de entrega, P será alocado ao caminhão que tiver menos itens a serem entregues. Considere que cada caminhão pode transportar até 20 itens.</li>
</ol></li>
<li>Para cada caminhão, imprime a rotina de entrega, no seguinte formato:</li>
</ul>
<p><strong>Percurso do caminhão &lt;PLACA1&gt;:</strong></p>
<ol style="list-style-type: lower-alpha;">
<li>Visitado ponto de entrega &lt;PONTO1&gt;. Foram entregues os itens:<br><ol style="list-style-type: lower-alpha;">
<li>&lt;ITEM1_PONTO1&gt;</li>
<li>&lt;ITEM2_PONTO1&gt;</li>
<li>&lt;ITEM3_PONTO1&gt;</li>
<li>(etc)</li>
</ol></li>
<li>Visitado ponto de entrega &lt;PONTO2&gt;. Foram entregues os itens:<br><ol style="list-style-type: lower-alpha;">
<li>&lt;ITEM1_PONTO2&gt;</li>
<li>&lt;ITEM2_PONTO2&gt;</li>
<li>&lt;ITEM3_PONTO2&gt;</li>
<li>(etc)</li>
</ol></li>
</ol>
<p>(etc)&nbsp; &nbsp; &nbsp; &nbsp;</p>
<p>Total de pontos de entrega: &lt;TOTAL_PONTOS1&gt;</p>
<p>Total de itens entregues: &lt;TOTAL_ITENS1&gt;</p>
<p></p>
