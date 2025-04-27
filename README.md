🎮 Trabalho Prático 01 - Análise do Jogo 2D "Breakout" (C++/SFML)
Repositório analisado: https://github.com/ogamal/breakout
(Warning:Analizaçao do trabalho)

1. Identificação do Grupo
Nome: Zongsheng Lin (Nº 31469)


2. Descrição da Implementação
Este projeto é a implementação do clássico jogo Breakout desenvolvido em C++, utilizando a biblioteca gráfica SFML (Simple and Fast Multimedia Library).

O objetivo do jogo é controlar uma barra para refletir uma bola que deve destruir todos os blocos dispostos no topo da tela.
O jogador perde o jogo se a bola cair abaixo da barra.

Decisões tomadas:
Utilização da biblioteca SFML para facilitar o controlo de gráficos, janelas e eventos do teclado.

Organização modular com classes separadas: Ball, Paddle, Brick, Game.

Utilização de sprites, texturas e fontes externas, organizadas na pasta assets/.

Separação clara entre a lógica do jogo, desenho dos elementos e gestão de eventos.

Instruções de jogo:
Mover a barra: Teclas Esquerda (←) e Direita (→).

Objetivo: Destruir todos os blocos no topo do ecrã.

Derrota: Deixar a bola cair para fora do ecrã.

3. Análise dos Ficheiros e Organização das Pastas
Estrutura do projeto:

breakout/
│
├── assets/
│   ├── fonts/
│   │   └── OpenSans-Bold.ttf
│   └── textures/
│       ├── ball.png
│       ├── block.png
│       └── paddle.png
│
├── src/
│   ├── ball.cpp
│   ├── ball.hpp
│   ├── block.cpp
│   ├── block.hpp
│   ├── game.cpp
│   ├── game.hpp
│   ├── paddle.cpp
│   └── paddle.hpp
│
├── main.cpp
├── README.md
├── CMakeLists.txt
└── LICENSE
Explicação das pastas e ficheiros:
assets/: contém os recursos usados pelo jogo (imagens e fontes).

src/: contém todo o código-fonte organizado em múltiplos ficheiros .cpp e .hpp.

main.cpp: ficheiro principal que inicia o jogo.

CMakeLists.txt: ficheiro de configuração para construir o projeto com CMake.

README.md: instruções básicas de instalação e execução.

LICENSE: licença do projeto (MIT License).

4. Análise dos Códigos
Organização:
Código muito bem modularizado, com cada entidade (bola, barra, bloco) numa classe separada (ball.hpp/.cpp, block.hpp/.cpp, paddle.hpp/.cpp).

game.hpp/.cpp gere o estado global do jogo, incluindo score e eventos.

Estilo:
Código limpo, com boas práticas de C++ (uso correto de headers, construtores, destrutores).

As funções têm nomes descritivos e são relativamente pequenas.

Uso adequado de referências e ponteiros para performance.

Principais funções e classes:
Game::run(): função que inicia o loop principal do jogo (update, handleEvents, render).

Ball::update(): atualiza a posição da bola e trata colisões com paredes, blocos e a barra.

Paddle::update(): move a barra com base nas teclas pressionadas.

Block::update(): verifica se o bloco foi atingido e o remove do jogo.

handleCollisions(): função que gere as colisões entre todos os elementos.

Boas práticas usadas:
Separação clara entre lógica de jogo e apresentação gráfica.

Utilização de constantes para parametrizar o jogo (velocidade, tamanhos, cores).

Organização modular facilita manutenção e evolução do código.

Utilização de SFML de maneira eficiente, aproveitando as classes sf::Sprite, sf::Texture, sf::Font, sf::Text.

Pequenos pontos a melhorar:
Poderia haver uma melhor gestão de níveis e dificuldades (atualmente é um nível fixo).

Faltam efeitos sonoros para colisões ou vitórias (SFML suporta áudio).

Algumas funções poderiam ser documentadas com comentários detalhados para facilitar a leitura de novos programadores.
