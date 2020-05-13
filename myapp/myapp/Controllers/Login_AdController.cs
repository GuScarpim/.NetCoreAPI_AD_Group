using Microsoft.AspNetCore.Mvc;
using myapp.Model;
using System.DirectoryServices.AccountManagement;

namespace myapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login_AdController : ControllerBase
    {
        [HttpPost]
        [Route("verificar")]
        //Essa rota irá pegar o conteúdo que está dentro da minha model e fazer uma validação
        public bool Post([FromBody]Verify_AD_Settings settings)
        {
            bool isValid = false;
            {
                //PrincipalContext é um método "Exclusivo" do DirectoryServices onde comparo com o Dominio da rede em que a pessoa está logada
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
                {
                    {
                        //Se o usuário e a senha existir dentro do AD ele retornará true (Isso serve para fazer um login com o AD sem utilizar um grupo específico)
                        //ValidateCredentials é outro método exclusivo do DirectoryServices
                        isValid = pc.ValidateCredentials(settings.User, settings.Password);
                        //GroupPrincipal e UserPrincipal também são outros métodos "Exclusivos do DirectoryServices"
                        //Valido se o usuário está dentro do grupo que foi especifícado na minha model
                        UserPrincipal user = UserPrincipal.FindByIdentity(pc, settings.User);
                        GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, settings.Group);
                        if (user != null)
                        {
                            // Checando se o usuário faz parte do grupo do AD
                            if (user.IsMemberOf(group))
                            {
                                isValid = true;
                            }
                            else
                            {
                                isValid = false;
                            }
                        }
                    }
                }
            }
            //Retorna true quando está contido no grupo e false para não estar contido em um grupo.
            return isValid;
        }
    }
}