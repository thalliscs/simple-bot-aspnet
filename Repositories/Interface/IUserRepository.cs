namespace SimpleBot
{
    public interface IUserRepository
    {
        void SalvarHistorico(Message message);

        UserProfile GetProfileById(string id);

        void SalvarUserProfile(UserProfile perfil);
    }
}