using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Domain
{
    public class BestiarioRecord : IEquatable<BestiarioRecord>, IEntity
    {

        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public int Hp { get; set; }
        public int Nivel { get; set; }
        public NivelPerigo NivelPerigo { get; set; }
        public Raridade Raridade { get; set; }
        public int Dano { get; set; }
        public int Defesa { get; set; }
        public DateTime DataRegistro { get; set; }
        public Tipo Tipo { get; set; }

        public BestiarioRecord() { }

        public BestiarioRecord(string id, string name, DateTime dataRegistro, string descricao = "",
            int hp = 1, int nivel = 1, NivelPerigo nivelPerigo = NivelPerigo.NENHUM,
            Raridade raridade = Raridade.COMUM, int dano = 1, int defesa = 1, Tipo tipo = Tipo.HUMANO)
        {
            Id = id;
            Nome = name ?? throw new ArgumentNullException(nameof(name));
            if (name.Length > 100) 
                throw new InvalidAttributeLengthException($"{nameof(Nome)}: {Nome.Length}");
            Descricao = descricao;
            if (descricao.Length > 255)
                throw new InvalidAttributeLengthException($"{nameof(Nome)}: {Nome.Length}");
            Hp = hp;
            Nivel = nivel;
            NivelPerigo = Enum.IsDefined(
                typeof(NivelPerigo), nivelPerigo) ? nivelPerigo : NivelPerigo.NENHUM;
            Raridade = Enum.IsDefined(
                typeof(Raridade), raridade) ? raridade : Raridade.COMUM;
            Dano = dano;
            Defesa = defesa;
            DateTime now = DateTime.Now;
            DataRegistro = (dataRegistro == DateTime.MinValue) ? now : dataRegistro;
            if (dataRegistro > now)
                throw new InvalidRegisterDateException("Data de Registro não deve ser " +
                    "posterior à data atual");
            Tipo = Enum.IsDefined(
                typeof(Tipo), tipo) ? tipo : Tipo.HUMANO;
        }

        public BestiarioRecord With(string id = null, string name = null, string descricao = null,
            int? hp = null, int? nivel = null, NivelPerigo? nivelPerigo = null,
            Raridade? raridade = null, int? dano = null, int? defesa = null,
            DateTime? dataRegistro = null, Tipo? tipo = null)
        {
            return new BestiarioRecord(
                id ?? this.Id,
                name ?? this.Nome,
                dataRegistro ?? this.DataRegistro,
                descricao ?? this.Descricao,
                hp ?? this.Hp,
                nivel ?? this.Nivel,
                nivelPerigo ?? this.NivelPerigo,
                raridade ?? this.Raridade,
                dano ?? this.Dano,
                defesa ?? this.Defesa,
                tipo ?? this.Tipo
            );
        }

        public BestiarioRecord Update(BestiarioRecord entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            BestiarioRecord novo = entity.With(dataRegistro: this.DataRegistro);
            return novo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BestiarioRecord);
        }

        // Não compara Ids
        public bool Equals(BestiarioRecord other)
        {
            return !(other is null) &&
                   Descricao == other.Descricao &&
                   Nome == other.Nome &&
                   Hp == other.Hp &&
                   Nivel == other.Nivel &&
                   NivelPerigo == other.NivelPerigo &&
                   Raridade == other.Raridade &&
                   Dano == other.Dano &&
                   Defesa == other.Defesa &&
                   DataRegistro == other.DataRegistro &&
                   Tipo == other.Tipo;
        }

        // Não usa Ids para o cálculo
        public override int GetHashCode()
        {
            int hashCode = -1605580273;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descricao);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + Hp.GetHashCode();
            hashCode = hashCode * -1521134295 + Nivel.GetHashCode();
            hashCode = hashCode * -1521134295 + NivelPerigo.GetHashCode();
            hashCode = hashCode * -1521134295 + Raridade.GetHashCode();
            hashCode = hashCode * -1521134295 + Dano.GetHashCode();
            hashCode = hashCode * -1521134295 + Defesa.GetHashCode();
            hashCode = hashCode * -1521134295 + DataRegistro.GetHashCode();
            hashCode = hashCode * -1521134295 + Tipo.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BestiarioRecord left, BestiarioRecord right)
        {
            return EqualityComparer<BestiarioRecord>.Default.Equals(left, right);
        }

        public static bool operator !=(BestiarioRecord left, BestiarioRecord right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"BESTIÁRIO=" +
                $"{{Id: {this.Id}, " +
                $"Nome: {this.Nome}, " +
                $"Descricao: {this.Descricao}, " +
                $"HP: {this.Hp}, " +
                $"Nível: {this.Nivel}, " +
                $"Dano: {this.Dano}, " +
                $"Defesa: {this.Defesa}, " +
                $"Tipo: {this.Tipo}, " +
                $"Nivel de Perigo: {this.NivelPerigo}, " +
                $"Raridade: {this.Raridade}, " +
                $"Data de Registro: {this.DataRegistro.ToString()}}}";
        }

    }


    public class Bestiario
    {
       
    }
}