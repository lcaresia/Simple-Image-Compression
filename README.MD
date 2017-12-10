# Simple Image Commpression 

Um simples compressor de imagem baseado em RGB.

Vamos imaginar que temos 4 píxeis [A(148, 125, 164), B(52, 63, 45), C(50, 67, 40), D(142, 253, 256)] <br />
Como podemos ver, o pixel B e C são muito parecidos, com um pequena diferença[R(2), G(4), B(5)], ou sejá, após passar pelo algoritmo os píxeis ficarão assim [A(148, 125, 164), B(52, 63, 45), C(52, 63, 45), D(142, 253, 256)].

## Como configurar
Para configurar você deve apenas modificar as seguites linhas:

```c#
static string path = "C:/Users/Lucas/source/repos/ConsoleApp1/ConsoleApp1/imgs/"; // Diretorio do arquivo completo, mas sem o nome do arquivo
static string file = "teste.png"; // Nome do arquivo com a extensão
static string extension = "png"; // Extensão do arquivo sem o ponto inicial

static int max_range_color = 5; // Aqui é o range maxima(para negativo tambem) que o programa irá fazer a troca de pixel.
```

Após iniciar o programa ele ira comprimir a quantidade de vezes que a variavel `max_range_color` contem.


## Exemplos
Agora vamos para exemplos reais com dados de cada compressão.

`O melhor range foi 1;` <br />
`871361 cores foram trocadas;` <br />
`A imagem diminuiu em 48%;` <br />
`Demorou 00:01:46.7085186 para executar.` <br />
<img src="https://i.imgur.com/yX2B8s2.jpg" width="400"><img src="https://i.imgur.com/kDdJVfc.jpg" width="400">

`O melhor range foi 5;` <br />
`1216604 cores foram trocadas;` <br />
`A imagem diminuiu em 25%;` <br />
`Demorou 00:01:23.6234001 para executar.` <br />
<img src="https://i.imgur.com/cXIfSXV.jpg" width="400"><img src="https://i.imgur.com/KyeBGko.jpg" width="400">

`O melhor range foi 5;` <br />
`2857412 cores foram trocadas;` <br />
`A imagem diminuiu em 11%;` <br />
`Demorou 00:06:08.3350937 para executar.` <br />
<img src="https://i.imgur.com/NicWIAN.jpg" width="400"><img src="https://i.imgur.com/E2y07mu.jpg" width="400">
