Trabalho Prático 01 - Análise do Jogo 2D "Breakout" (C#/MonoGame)
https://github.com/mmowbray/Breakout (github file utilizado)

1. Identificação do Grupo
Nome: Zongsheng Lin(Nº 31469)


2. Descrição da Implementação
Este projeto é a implementação do jogo Breakout utilizando C# e a framework MonoGame.

O objetivo do jogo é controlar uma barra para refletir uma bola, destruindo todos os blocos dispostos no topo da tela. O jogador perde quando a bola ultrapassa a barra e cai fora da tela.

Decisões tomadas:
Uso de MonoGame: motor leve para criação de jogos 2D em C#.

Organização em classes separadas: Ball, Paddle, Brick, e Game1 (classe principal).

Uso de texturas simples para desenhar a bola, a barra e os blocos.

Implementação manual das colisões e física básica (não utiliza motor físico externo).

Definição de constantes para fácil ajuste da velocidade, tamanhos e posições.

Instruções de jogo:
Mover a barra: teclas Esquerda (←) e Direita (→).(espaço para resetar ou continuar)

Objetivo: destruir todos os blocos.

Derrota: deixar a bola passar abaixo da barra.

3. Análise dos Ficheiros e Organização das Pastas
Estrutura do projeto:

Breakout/
│
├── Project1/(esqueci mudar o nome quando criei e pastei o ficheiro para novo VSudio monogame)
│   ├── Ball.cs
│   ├── Block.cs
│   ├── BlockManager.cs
│   ├── Player.cs
│   ├── Game1.cs
│   ├── GameObject.cs
│   ├── Utils.cs
│   └── Program.cs
│
├── Content/
│   ├── ball.png
│   ├── block.png
│   ├── player.png
│   ├── hit.wav (som da collisao entra ball e block)
│   ├── lose.wav (simples,quando perdes)
│   ├── 3up.wav (quando acabas o jogo,como projeto nao ha proximo nivel,won.wav ou win.wav parece mais certo)
│   └── Content.mgcb 
│
├── projet1.csproj
└── README.md


Explicação das pastas e ficheiros:
project/: código-fonte principal em C#.

Game1.cs: loop principal do jogo (update, draw, gestão de estados).

Ball.cs: comportamento da bola (movimento, colisões).

Player.cs: lógica da barra controlada pelo jogador.

Block.cs: representação dos blocos que devem ser destruídos.

BlockManager.cs: collisao do bloco,deteção do vencimento e eliminacao do bloco

GameObject.cs: tela do jogo

Program.cs: ponto de entrada que inicia o jogo.

Content/: recursos gráficos usados no jogo.

ball.png, brick.png, paddle.png: imagens para representar os objetos do jogo.

Breakout.csproj: ficheiro de projeto C# para Visual Studio.

README.md: descrição básica do projeto.

hit,lose,3up.wav: sonoras do jogo  

4. Análise dos Códigos
Organização:
Cada entidade (bola, barra, bloco) tem sua própria classe (Ball, Paddle, Brick).

Game1 atua como o controlador principal, gerindo o ciclo de vida do jogo (entrada de utilizador, atualização, desenho).

Separação clara entre lógica de movimento, deteção de colisões e rendering.

Estilo:
Código simples e legível.

Utiliza boas práticas de C# como propriedades (get/set) e construtores organizados.

Utilização correta de sprites e vetores (Vector2) para gerenciar posições.

Utilização de soms para uma melhor experiência de jogo

Principais funções e classes:
Ball.Update(): atualiza a posição da bola e trata colisões com as paredes, a barra e os blocos.

Player.Move(): move a barra em resposta às teclas pressionadas.

Block.Draw(): desenha os blocos no ecrã se eles ainda não foram destruídos.

Game1.Update(): chamada em cada frame para atualizar todos os objetos do jogo.

Game1.Draw(): responsável por desenhar todos os elementos na tela.

Utils.isColliding(): colisao da parede/limite do jogo. 

Boas práticas usadas:
Separação de responsabilidades: cada classe faz apenas uma função específica.

Gestão de colisões feita de forma manual e clara (sem usar física pesada).

Código comentado em pontos-chave para ajudar na compreensão.

Pequenos pontos que poderiam ser melhorados:
O jogo atualmente tem apenas um nível e não descreve quantas vidas sao(sao 3 na verdade).(adicionei codigo para que consiga ver quantas vida tem)

Possui poucos efeitos sonoros ou música.

Não há um menu inicial 

(um jogo mesmo simples.)
