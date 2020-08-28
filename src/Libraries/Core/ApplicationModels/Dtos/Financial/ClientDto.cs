using System;
using System.Linq;
using Core.Entities;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class ClientDto
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