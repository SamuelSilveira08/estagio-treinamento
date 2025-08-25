using System;
using System.Collections.Generic;

namespace Domain
{
    public class BestiarioRecord : IEquatable<BestiarioRecord>, IEntity
    {

        public string Id { get; private set; }
        public string Descricao { get; private set; }
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Nivel { get; private set; }
        public NivelPerigo NivelPerigo { get; private set; }
        public Raridade Raridade { get; private set; }
        public int Dano { get; private set; }
        public int Defesa { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public Tipo Tipo { get; private set; }

        public BestiarioRecord(string id, string name, String descricao, DateTime dataRegistro,
            int hp = 1, int nivel = 1, NivelPerigo nivelPerigo = NivelPerigo.NENHUM,
            Raridade raridade = Raridade.COMUM, int dano = 1, int defesa = 1, Tipo tipo = Tipo.HUMANO)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Hp = hp;
            Nivel = nivel;
            NivelPerigo = Enum.IsDefined(
                typeof(NivelPerigo), nivelPerigo) ? nivelPerigo : NivelPerigo.NENHUM;
            Raridade = Enum.IsDefined(
                typeof(Raridade), raridade) ? raridade : Raridade.COMUM;
            Dano = dano;
            Defesa = defesa;
            DataRegistro = (dataRegistro == DateTime.MinValue) ? DateTime.Now : dataRegistro;
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
                name ?? this.Name,
                descricao ?? this.Descricao,
                dataRegistro ?? this.DataRegistro,
                hp ?? this.Hp,
                nivel ?? this.Nivel,
                nivelPerigo ?? this.NivelPerigo,
                raridade ?? this.Raridade,
                dano ?? this.Dano,
                defesa ?? this.Defesa,
                tipo ?? this.Tipo
            );
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
                   Name == other.Name &&
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
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
                $"Nome: {this.Name}, " +
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