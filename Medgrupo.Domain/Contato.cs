public class Contato
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;

    // Requisito 1a: Idade processada em tempo de execução
    public int Idade => CalcularIdade();

    private int CalcularIdade()
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataNascimento.Year;
        if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
        return idade;
    }

    // Requisitos 1b, 1c e 1d: Validações
    public (bool Valid, string Error) Validar()
    {
        if (DataNascimento > DateTime.Now)
            return (false, "A data de nascimento não pode ser maior que hoje.");

        if (Idade == 0)
            return (false, "A idade não pode ser igual a 0.");

        if (Idade < 18)
            return (false, "O contato deve ser maior de idade.");

        return (true, string.Empty);
    }
}