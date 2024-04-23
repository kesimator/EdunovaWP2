using AutoMapper;
using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class MappingGrupa
    {

        public static List<GrupaDTORead> MapGrupaReadList(this List<Grupa> lista)
        {
            
            var mapper = GrupaMapper.InicijalizirajReadToDTO();
            var vrati = new List<GrupaDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<GrupaDTORead>(e));
            });
            return vrati;

            /*
             * IDEJA: ručno napuniti record
            var vrati = new List<GrupaDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(new GrupaDTORead(1,"",""));
            });
            return vrati;
            */
        }

        public static GrupaDTORead MapGrupaReadToDTO(this Grupa entitet)
        {
            var mapper = GrupaMapper.InicijalizirajReadToDTO();
            return mapper.Map<GrupaDTORead>(entitet);
        }

        public static GrupaDTOInsertUpdate MapGrupaInsertUpdatedToDTO(this Grupa entitet)
        {
            var mapper = GrupaMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<GrupaDTOInsertUpdate>(entitet);
        }

    }
}