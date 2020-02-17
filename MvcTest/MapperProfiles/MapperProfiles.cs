using AutoMapper;


namespace MvcTest.MapperProfiles
{
    public class MapperProfiles : Profile
    {

        // ponieważ aplikacja jest mała wystarczy jeden pliczek MapperProfiles, jeżeli miałaby się rozrosnąć
        // można dodawać kolejne klasy np. PersonProfile, dzidziczące po klasie Profile. 
        // będą one automatycznie rejestrowane w module Autofac AutoMapperModule, dziedziczącym po klasie Module

        public MapperProfiles()
        {





        }

    }
}