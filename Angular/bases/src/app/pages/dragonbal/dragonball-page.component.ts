import { NgClass } from "@angular/common";
import { ChangeDetectionStrategy, Component, computed, signal } from "@angular/core";


interface Character {
    id: number;
    name: string;
    powerLevel: number;
}

@Component({    
    selector: 'app-dragonball-page',
    imports: [NgClass],
    templateUrl: './dragonball-page.component.html',
    styleUrls: ['./dragonball-page.component.css'],

    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DragonBallPageComponent {

    name = signal('Trunks');
    powerLevel = signal(3000);

    characters = signal<Character[]>([
        {
            id: 1,
            name: 'Goku',  
            powerLevel: 9001    
        },
        {
            id: 2,
            name: 'Vegeta',  
            powerLevel: 8500    
        },
        {
            id: 3,
            name: 'Gohan',  
            powerLevel: 7000    
        },
        {
            id: 4,
            name: 'Piccolo',  
            powerLevel: 6000    
        },
        {
            id: 5,
            name: 'Saybayman',  
            powerLevel: 500    
        },
        {
            id: 6,
            name: 'Krillin',  
            powerLevel: 3000
        }
    ]);

    addCharacter() {
        if (!this.name() || this.powerLevel() <= 0) {
            console.warn('Invalid character data. Name must be provided and power level must be greater than 0.');
            return;
        }

        const newCharacter: Character = {
            id: this.characters().length + 1,
            name: this.name(),
            powerLevel: this.powerLevel()
        };
        this.characters.update(chars => [...chars, newCharacter]);

        console.log('Character added:', newCharacter);
        this.resetFields();
    }

    resetFields() {
        this.name.set('');
        this.powerLevel.set(0);
    }

    powerClass = computed(() => {
        return{
            'text-danger': true,
        }
    });

}