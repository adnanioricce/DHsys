using Core.Entities;

namespace Core.Models.Dtos.Financial
{
    public class ClientDto : BeneficiaryDto
    {        
        public string Cpf { get; set; }

        public static ClientDto FromModel(Client model)
        {
            return new ClientDto()
            {
                Cpf = model.Cpf, 
            }; 
        }

        public Client ToModel()
        {
            return new Client()
            {
                Cpf = Cpf, 
            }; 
        }
    }
}