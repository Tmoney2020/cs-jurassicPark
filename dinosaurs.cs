using System;

namespace cs_jurassicPark

{


    //  Create a class to represent your dinosaurs. The class should have the following properties

    //  Name
    //  DietType - This will be "carnivore" or "herbivore"
    //  WhenAcquired - This will default to the current time when the
    //  dinosaur is created
    //  Weight - How heavy the dinosaur is in pounds.
    //  EnclosureNumber - the number of the pen the dinosaur is currently in
    //  Add a method Description to your class to print out a description of the dinosaur to include all of its properties. Create an output format of your choosing.
    class Dinosaurs
    {
        public string Name
        {
            get; set;
        }
        public string DietType
        {
            get; set;
        }

        public DateTime WhenAcquired
        {
            get; set;
        }

        public int Weight
        {
            get; set;
        }

        public int EnclosureNumber
        {
            get; set;
        }

        public string Description()
        {
            var eachDinosaursDescription = $" {Name} is a {DietType} that weights {Weight} tons. It is kept in enclosure {EnclosureNumber} and aquired on {WhenAcquired}  ";

            return eachDinosaursDescription;
        }
    }

}