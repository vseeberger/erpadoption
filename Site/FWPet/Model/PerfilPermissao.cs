using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class PerfilPermissao
    {
        #region Atributos
        private Formulario formulario;
        private Perfil perfil;
        private bool abrir;
        private bool pesquisar;
        private bool inserir;
        private bool alterar;
        private bool excluir;
        private bool especial;
        #endregion

        #region Propriedades
        public Formulario Formulario
        {
            get { return formulario; }
            set { formulario = value; }
        }
        public Perfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }
        public bool Abrir
        {
            get { return abrir; }
            set { abrir = value; }
        }
        public bool Pesquisar
        {
            get { return pesquisar; }
            set { pesquisar = value; }
        }
        public bool Inserir
        {
            get { return inserir; }
            set { inserir = value; }
        }
        public bool Alterar
        {
            get { return alterar; }
            set { alterar = value; }
        }
        public bool Excluir
        {
            get { return excluir; }
            set { excluir = value; }
        }
        public bool Especial
        {
            get { return especial; }
            set { especial = value; }
        }
        #endregion

        public static List<PerfilPermissao> Listar(long _Perfil)
        {
            return DaoPerfilPermissao.Pesquisar(_Perfil);
        }
    }
}