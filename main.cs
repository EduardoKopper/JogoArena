using System;

class Personagem {
  public string Nome { get; set; }
  public int Idade { get; set; }
  public int Vida { get; set; }
  public string Tipo { get; set; }

  public Personagem() { }

  public Personagem(string nome){
    Nome = nome;
  }
  
  public Personagem(string nome, int idade, int vida, string tipo){
    Nome = nome;
    Idade = idade;
    Vida = vida;
    Tipo = tipo;
  }
}

class Arena {
  public static (Personagem, Personagem) Dano(Personagem a, Personagem b) {
    if (a.Tipo.Equals(b.Tipo, StringComparison.OrdinalIgnoreCase)) return (a, b);
    
    int dano = 0;
    if (a.Tipo.Equals("heroi", StringComparison.OrdinalIgnoreCase)) {
      dano = 10;
    } else if (a.Tipo.Equals("vilao", StringComparison.OrdinalIgnoreCase)) {
      dano = 5;
    }

    b.Vida -= dano;
    return (a, b);
  }
}

class Program {
  public static void Main (string[] args) {
    Personagem capitaoMarvel = new Personagem {
      Nome = "Capitã Marvel",
      Idade = 23,
      Vida = 1000,
      Tipo = "heroi"
    };
    Personagem flash = new Personagem("Flash"){
      Idade = 25,
      Vida = 99,
      Tipo = "heroi"
    };
    Personagem batman = new Personagem("Batman", 42, 80, "vilao");

    (batman, capitaoMarvel) = Arena.Dano(batman, capitaoMarvel);
    (flash, batman) = Arena.Dano(flash, batman);
    (batman, flash) = Arena.Dano(batman, flash);
    Console.WriteLine("Capitã Marvel: " + capitaoMarvel.Vida);
    Console.WriteLine("Flash: " + flash.Vida);
    Console.WriteLine("Batman: " + batman.Vida);
  }
}
