namespace SimpleBot
{
    public interface IUserSqlRepository
    {
        void SalvarHistorico(Message message);

        UserProfile GetProfileById(string id);

        void SalvarUserProfile(UserProfile perfil);
    }
}