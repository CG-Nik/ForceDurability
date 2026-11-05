# ForceDurability
This mod forces add vanilla materials and modded materials (made through MateriaLib) to use Durability.  
This mod needs to be on the Server only.  
This mod requires that you also have https://github.com/Circl-NoE/ATTMateriaLib downloaded to work properly.  

This mod forces Durability to be used in two ways.  
Firstly, it sets the MelonPreferences entry for using vanillaDurability to true, and forcefully sets the useDurabilityMultiplier of every LibMaterial to true.  
Secondly, it also forces the GetMultiplier() method in MaterialDurability to always return the material's durability multiplier, as long as that material isn't null.  

This is an unofficial, fan-made mod for A Township Tale. This mod is not affiliated with or endorsed by the owners or developers of A Township Tale.  
