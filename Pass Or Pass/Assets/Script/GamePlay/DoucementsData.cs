
using System.Collections.Generic;

public enum Types
{
    Raw_materials,
    Vehicles,
    Materials,
    Organics,
    Medicals,
    Electronics
}
public static class DoucementsData
{
    public static Dictionary<Types, string[]> TypesData;

    private static string[]
    #region data
      Raw_materials = { "Titanium", "Limestone", "Phosphates", "Nickel", "Magnesium", "Plutonium", "Neodymium", "Cobalt", "Chromium", "Vanadium", "Manganese", "Tungsten", "Radium", "Mercury", "Rare earth elements", "Antimony", "Zirconium", "Lithium", "Cadmium", "Molybdenum", "Indium", "Platinum", "Palladium", "Rhodium", "Iridium", "Osmium", "Ruthenium", "Gallium", "Scandium", "Rhodium", "Lanthanum", "Thulium", "Tellurium", "Rhenium", "Yttrium", "Erbium", "Praseodymium", "Samarium", "Bismuth", "Strontium", "Barium", "Cesium", "Rubidium", "Niobium", "Hafnium", "Tantalum", "Tin", "Lead" },
      vehicles = { "Electric car", "Segway", "Amphibious vehicle", "Unicycle", "Electric skateboard", "Go-kart", "Monowheel", "Tricycle", "Zipline", "Rowboat", "Gliders", "Jet surfboard", "Rocket-powered sled", "Drone", "Tuk-tuk", "Racing wheelchair", "Monster truck", "Ice resurfacer", "Snowcat", "Horse-drawn carriage", "Zeppelin", "Cable car", "Gyrocopter", "Tandem bicycle", "Jet levitation", "Moon rover", "Spaceship", "Rocket", "Electric scooter", "Electric unicycle", "Human-powered aircraft", "Paraglider", "Skydiving wing suit", "Hot rod", "Mini submarine", "Underwater scooter", "Jet ski", "Segway PT", "Tank", "Aerial tramway", "Hang glider", "Amusement park ride", "Dirt bike", "Space shuttle", "Harley Davidson", "Bullet train", "Tractor", "Hovercraft", "Solar car" },
      Materials = { "Kevlar", "Alloy", "Rubberized fabric", "Ceramic fiber", "Balsa wood", "Aramid fiber", "Aluminum foam", "Carbon nanotubes", "Thermoplastic", "Concrete canvas", "Refractory materials", "Insulating refractories", "Refractory metals", "Clay", "Polyurethane foam", "Polyimide", "Polycarbonate", "Polypropylene", "Polyethylene terephthalate", "Polyvinyl chloride", "Fibrous materials", "Composite material", "Thermosetting plastic", "Ferroalloys", "Galvanized steel", "Aluminized steel", "Beryllium copper", "Glass fiber", "Carbon fiber reinforced polymer", "Graphene", "Fiberglass reinforced plastic", "Metal matrix composite", "Thermoplastic composite", "Cement", "Wood plastic composite", "Thermal insulation material", "Soundproofing material", "Reflective material", "Adhesive tape", "Abrasive material", "Teflon", "Quartz glass", "Ceramic matrix composite", "Superconductor", "Smart material", "Biodegradable plastic", "Titanium alloy" },
      Organics = { "Seaweed", "Pine nuts", "Sunflower seeds", "Chia seeds", "Hemp seeds", "Flaxseeds", "Alfalfa", "Millet", "Rye", "Oats", "Sesame seeds", "Peanuts", "Macadamia nuts", "Pistachios", "Cashews", "Hazelnuts", "Walnuts", "Pecans", "Cranberries", "Goji berries", "Cherries", "Blueberries", "Raspberries", "Blackberries", "Strawberries", "Acai berries", "Passion fruit", "Dragon fruit", "Guava", "Mango", "Papaya", "Pineapple", "Kiwi", "Banana", "Coconut water", "Almond milk", "Soy milk", "Cashew milk", "Quinoa", "Brown rice", "Whole wheat", "Barley", "Cacao", "Turmeric", "Ginger", "Garlic", "Onions", "Basil", "Cilantro", "Rosemary" },
      Medicals = { "Stethoscope", "Blood glucose monitor", "Pulse oximeter", "Ophthalmoscope", "Otoscope", "Thermometer", "Sphygmomanometer", "Nebulizer", "Electrocardiogram (ECG or EKG)", "Fetal monitor", "Anesthesia machine", "Ventilator", "Infusion pump", "Defibrillator", "Medical imaging equipment", "CT scanner", "X-ray machine", "Ultrasound machine", "Dental chair", "Endoscope", "Surgical microscope", "Autoclave", "Dialysis machine", "Hospital bed", "Wheelchair", "Crutches", "Orthopedic brace", "Prosthetic limb", "Hearing aid", "Orthodontic braces", "Insulin pump", "Pacemaker", "Cochlear implant", "Intraocular lens", "Catheter", "Surgical gloves", "Face mask", "Gauze", "Bandages", "Antibiotics", "Antiviral drugs", "Painkillers", "Vaccines", "Antiseptics", "Antifungal medications", "Antihistamines", "Anti-inflammatory drugs", "Anti-coagulants", "Psychoactive medications" },
      Electronics = { "Smartphone", "Laptop", "Tablet", "Smartwatch", "Fitness tracker", "Digital camera", "Headphones", "Bluetooth speaker", "Game console", "Drone", "VR headset", "Smart TV", "Router", "Computer mouse", "Keyboard", "Printer", "Scanner", "External hard drive", "USB flash drive", "Power bank", "Wireless earbuds", "Smart thermostat", "Smart doorbell", "Robot vacuum", "E-reader", "Digital voice assistant", "Action camera", "Wireless charger", "Graphics tablet", "Studio headphones", "Gaming mouse", "Gaming keyboard", "Graphics card", "Smart home hub", "Mini projector", "Digital photo frame", "Car GPS", "Fitness smart scale", "Electric toothbrush", "Electronic translator", "Security camera", "LED light strips", "Electronic dartboard", "Portable DVD player", "Wireless presenter", "Electronic drum set", "Electric scooter", "Electric toothbrush", "3D printer", "Smart refrigerator", "Digital microscope" };
    #endregion
    
    public static string[]
    #region data

      Names = { "John Smith", "Michael Johnson", "William Brown", "David Davis", "James Miller", "Robert Wilson", "Joseph Moore", "Richard Taylor", "Daniel Anderson", "Matthew Thomas", "Christopher Martinez", "Andrew Jackson", "Brian Harris", "Edward Thompson", "Kevin White", "Mark Martin", "George Garcia", "Steven Robinson", "Thomas Rodriguez", "Charles Lewis", "Timothy Lee", "Jason Hall", "Jeffrey Young", "Ryan King", "Nicholas Scott", "Eric Baker", "Adam Cooper", "Paul Hill", "Scott Turner", "Justin Nelson", "Kenneth Reed", "Brian Wright", "Anthony Evans", "Jonathan Murphy", "Derek Rivera", "Brandon Carter", "Gary Perez", "Peter Stewart", "Nathan Phillips", "Walter Foster", "Samuel Ward", "Craig Butler", "Bryan Simmons", "Donald Foster", "Raymond Hayes", "Alexander Barnes", "Benjamin Mitchell", "Patrick Powell", "Larry Jenkins" },
      countries = { "South Africa", "Nigeria", "Kenya", "Morocco", "Ethiopia", "Ghana", "Tanzania", "Uganda", "Algeria", "Zimbabwe", "Botswana", "Mali", "Senegal", "Ivory Coast", "Cameroon", "Angola", "Rwanda", "Burundi", "Malawi", "Namibia", "Mauritius", "Seychelles", "Togo", "Lesotho", "Sudan", "South Sudan", "Libya", "Tunisia", "Egypt", "Sierra Leone", "Liberia", "Guinea", "Benin", "Niger", "Chad", "Burkina Faso", "Djibouti", "Comoros", "Eritrea", "Somalia", "Madagascar", "Zambia", "Swaziland", "Mozambique", "Congo", "Gabon", "Cape Verde" };
      
    #endregion

    public static Dictionary<Types, string[]> TypeData() 
    {
       
        TypesData = new Dictionary<Types, string[]>()
        {
          {Types.Raw_materials, Raw_materials },
          {Types.Materials,     Materials     },
          {Types.Organics,      Organics      },
          {Types.Medicals,      Medicals      },
          {Types.Vehicles,      vehicles      },
          {Types.Electronics,   Electronics   }
        };
        return TypesData;
    }

}
