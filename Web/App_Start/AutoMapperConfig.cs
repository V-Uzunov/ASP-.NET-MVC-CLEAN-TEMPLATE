namespace Web.App_Start
{
    using AutoMapper;

    public class AutoMapperConfig
    {
        public static void ConfigureAutomapper()
        {
            ////Add mapper config
            Mapper.Initialize(action =>
            {
            });
        }
    }
}