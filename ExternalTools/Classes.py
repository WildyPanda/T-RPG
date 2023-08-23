import json

class ArchivedStats:
    def __init__(self, nbElement):
        print("ArchivedStats : ");
        self.level = int(input("Level : (int) "));
        self.stage = int(input("Stage : (int) "));
        self.health = int(input("Health : (int) "));
        self.speed = int(input("Speed : (int) "));
        self.globalAttack = int(input("GlobalAttack : (int) "));
        self.attack = [int(input(f"Attack ({i}) : (int) ")) for i in range(nbElement)]
        self.globalDefense = int(input("GlobalDefense : (int) "));
        self.defense = [int(input(f"Defense ({i}) : (int) ")) for i in range(nbElement)]
    
    def toJson(self, id):
        strId = f'"$id": {id}'
        strLevel = f'"level": {self.level}'
        strStage = f'"stage": {self.stage}'
        strHealth = f'"health": {self.health}'
        strSpeed = f'"speed": {self.speed}'
        strGlobalAttack = f'"globalAttack": {self.globalAttack}'
        strAttack = f'"attack": ['
        for i in self.attack:
            strAttack += f'{i},'
        strAttack = strAttack[:-1] + f']'
        strGlobalDefense = f'"globalDefense": {self.globalDefense}'
        strDefense = f'"defense": ['
        for i in self.defense:
            strDefense += f'{i},'
        strDefense = strDefense[:-1] + f']'
        line = "{\n" + strId + ",\n" + strLevel + ",\n" + strStage + ",\n" + strHealth + ",\n" + strSpeed + ",\n" + strGlobalAttack + ",\n" + strAttack + ",\n" + strGlobalDefense + ",\n" + strDefense + "\n}"
        return(line)

test = ArchivedStats(3);
print(test.toJson(3))