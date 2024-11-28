namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é suficiente para o número de hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção caso a capacidade seja insuficiente
                throw new ArgumentException("A capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da diária
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% caso os dias reservados sejam 10 ou mais
            if (DiasReservados > 10)
            {
                valor -= valor * 0.10m;
            }

            return valor;
        }
    }
}
