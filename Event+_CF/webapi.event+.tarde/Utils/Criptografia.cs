namespace webapi.event_.tarde.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma Hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá essa senha</param>
        /// <returns>Senha criptografada com a Hash</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Verifica se a Hash da senha informada é igual a Hash salva no bd
        /// </summary>
        /// <param name="senhaForm">Senha passada no form de Login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns></returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
