namespace ApplicationCore.Interface.IServices
{
    public interface IContraseniaService
    {
        string Hash(string? password);
        bool Check(string? hash, string? password);
    }
}
