using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace pet_hotel
{
    public enum PetBreedType {
        Shepherd, 
        Poodle, 
        Beagle, 
        Bulldog, 
        Terrier, 
        Boxer, 
        Labrador, 
        Retriever
    }
    public enum PetColorType {
        White, 
        Black, 
        Brown,
        Golden, 
        Tricolor, 
        Spotted
    }
    public class Pet {
        public int id {get; set;}

        [Required]
        public string name {get; set;}

        [ForeignKey("petOwner")]
        public int petOwnerid {get; set;}

        public PetOwner petOwner {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed{get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color{get; set;}

        public static DateTime checkedInAt {get; set;}

        // public bool checkedInAt {get; set;}
        // public static DateTime checkedInAt{get; set;}

    }
}
