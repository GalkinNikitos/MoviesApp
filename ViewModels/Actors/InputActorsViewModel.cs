using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filtres;

namespace MoviesApp.ViewModels.Actors;

public class InputActorsModel
{
    [ValidationOfNameOfActor]
    public string Name { get; set; }
        
    [ValidationOfNameOfActor]
    public string Surname { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}