import { ChangeDetectionStrategy, Component, inject, Inject } from "@angular/core";
import { DragonballService } from './../../services/dragonball.service';
import { DragonballCharacterAdd } from '../../components/dragonball/dragonball-character-add/dragonball-character-add';
import { CharacterList } from '../../components/dragonball/character-list/character-list';


@Component({    
    selector: 'dragonball-super-page',
    imports: [CharacterList, DragonballCharacterAdd],
    templateUrl: './dragonball-super-page.component.html',
    styleUrls: ['./dragonball-super-page.component.css'],

    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DragonBallSuperPageComponent { 

    public dragonballService = inject(DragonballService);
}