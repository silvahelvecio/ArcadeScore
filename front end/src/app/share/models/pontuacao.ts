export class pontuacao  {
    public id!: number;
    public jogadorId!: number;
    public data!: string;
    public pontos!: number;
}

export class jogadores  {
    public id!: number;
    public nome!: string;
}


export class estatistica  {
    public jogadorId!: number;
    public partidasJogadas!: number;
    public mediaPontuacao!: number;
    public maiorPontuacao!: number;
    public menorPontuacao!: number;
    public qtdeVezesRecord!: number;
    public tempoJoga!: number;
}
