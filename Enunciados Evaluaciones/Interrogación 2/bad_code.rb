# He knows the way
class Mando
  attr_accessor :hp

  def initialize
    @hp = 100
    @power_attack = 10
  end

  def shot(enemy)
    attack = (@power_attack * rand).to_i
    enemy.hp -= attack
    p "bang (-#{attack})"
  end

  def walk
    p 'walking'
  end
end

# A cute baby
class Baby
  attr_accessor :hp

  def initialize
    @hp = 50
    @power_attack = 100
  end

  def the_force(enemy)
    attack = @power_attack * rand
    enemy.hp -= attack
    @hp -= 2
    p "*magic sounds* (-#{attack})"
  end

  def walk
    p 'walking'
  end
end

# Someone evil
class Enemy
  attr_accessor :hp

  def initialize
    @hp = 20
    @power_attack = 1
  end

  def attack(someone)
    attack = (@power_attack * rand).to_i
    someone.hp -= attack
    p "bang (-#{attack})"
  end

  def walk
    p 'walking'
  end
end

# Runs the simulation
class Main
  def self.run
    mando = Mando.new
    baby = Baby.new
    enemies = [Enemy.new, Enemy.new]

    while enemies.map(&:hp).reduce(0, :+) > 0 || (mando.hp <= 0 || baby.hp <= 0)
      mando.walk if mando.hp > 0
      baby.walk if baby.hp > 0
      enemies[0].walk if enemies[0].hp > 0
      enemies[1].walk if enemies[1].hp > 0
      mando.shot(enemies[0])
      mando.shot(enemies[1])
      if mando.hp < 10
        baby.the_force(enemies[0])
        baby.the_force(enemies[1])
      end
    end
  end
end

Main.run
