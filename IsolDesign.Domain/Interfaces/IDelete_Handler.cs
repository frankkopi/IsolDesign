namespace IsolDesign.Domain.Interfaces
{
    public interface IDelete_Handler
    {
        void DeleteApplicant(int id);

        void DeleteApplicantAndPortfolio(int id);
    }
}
