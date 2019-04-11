using FWPet.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace FWPet.Model
{
    public class ColaboradorEscala
    {
        #region Atributos
        private long id;
        private string sNomeColaborador;
        private DateTime dtmInicio;
        private DateTime? dtmFinal;
        private string sUrl;
        private string sClasse;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private string sDescricao;
        private long? idColaborador;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "title")]
        public string SNomeColaborador
        {
            get { return sNomeColaborador; }
            set { sNomeColaborador = value; }
        }
        [JsonProperty(PropertyName = "start", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "start")]
        public DateTime DtmInicio
        {
            get { return dtmInicio; }
            set { dtmInicio = value; }
        }
        [JsonProperty(PropertyName = "end", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "end")]
        public DateTime? DtmFinal
        {
            get { return dtmFinal; }
            set { dtmFinal = value; }
        }
        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "url")]
        public string SUrl
        {
            get { return sUrl; }
            set { sUrl = value; }
        }
        [JsonProperty(PropertyName = "className", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "className")]
        public string SClasse
        {
            get { return sClasse; }
            set { sClasse = value; }
        }
        [JsonIgnore]
        [XmlIgnore]
        public DateTime DtmCadastro
        {
            get { return dtmCadastro; }
            set { dtmCadastro = value; }
        }
        [JsonIgnore]
        [XmlIgnore]
        public DateTime DtmUltAlt
        {
            get { return dtmUltAlt; }
            set { dtmUltAlt = value; }
        }
        [JsonIgnore]
        [XmlIgnore]
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string SDescricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
        }
        [JsonIgnore]
        [XmlIgnore]
        public long? IdColaborador
        {
            get { return idColaborador; }
            set { idColaborador = value; }
        }
        #endregion

        public static List<ColaboradorEscala> Escalas(string _MesAno, long _Colaborador)
        {
            return DaoColaboradorEscala.Escalas(_MesAno, _Colaborador);
        }
        public static List<ColaboradorEscala> Escalas(string _MesAnoInicio, string _MesAnoTermino, long _Colaborador)
        {
            return DaoColaboradorEscala.Escalas(_MesAnoInicio, _MesAnoTermino, _Colaborador);
        }

        public static string JsonEscalas(string _MesAnoInicio, string _MesAnoTermino, long _Colaborador)
        {
            //var jsonSerialiser = new JavaScriptSerializer();
            //return jsonSerialiser.Serialize(DaoColaboradorEscala.Escalas(_MesAno, _Colaborador));
            var jsonSerialiser = Newtonsoft.Json.JsonConvert.SerializeObject(DaoColaboradorEscala.Escalas(_MesAnoInicio, _MesAnoTermino, _Colaborador));
            return jsonSerialiser;
        }

        public void Salvar()
        {
            DaoColaboradorEscala.Salvar(this);
        }

        public void Excluir()
        {
            DaoColaboradorEscala.Excluir(this);
        }

        public static ColaboradorEscala Obter(long _Escala)
        {
            return DaoColaboradorEscala.Obter(_Escala);
        }
    }
}