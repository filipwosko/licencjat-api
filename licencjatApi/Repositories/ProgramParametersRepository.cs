using licencjatApi.Data;

namespace licencjatApi.Repositories
{
    public class ProgramParametersRepository : IProgramParametersRepository
    {
        public string MethodName
        {
            get => GetStringParameter("MethodName");
            set => SetParameter("MethodName", value);
        }

        private readonly DataContext _dataContext;

        public ProgramParametersRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private string GetStringParameter(string key) => _dataContext.Parameters.Single(p => p.Key == key).Value;
        private void SetParameter(string key, object value)
        {
            var parameter = _dataContext.Parameters.Single(p => p.Key == key);
            parameter.Value = value?.ToString() ?? "";
            _dataContext.SaveChanges();
        }
    }
}
