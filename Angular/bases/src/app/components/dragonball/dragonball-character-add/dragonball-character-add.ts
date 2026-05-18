import { ChangeDetectionStrategy, Component, output, signal } from '@angular/core';
import { Character } from '../../../interfaces/character.interface';


@Component({
  selector: 'dragonball-character-add',
  imports: [],
  templateUrl: './dragonball-character-add.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DragonballCharacterAdd {

  name = signal('');
  powerLevel = signal(0);

  newCharacter = output<Character>();
  
  addCharacter() {
      if (!this.name() || this.powerLevel() <= 0) {
          return;
      }
      
      const character: Character = {
          id: Math.random(),
          name: this.name(),
          powerLevel: this.powerLevel()
      };
      
      this.newCharacter.emit(character);
      this.resetFields();
  }

  resetFields() {
      this.name.set('');
      this.powerLevel.set(0);
  }
}
