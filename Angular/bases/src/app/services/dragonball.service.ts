import { effect, Injectable, signal } from '@angular/core';
import { Character } from '../interfaces/character.interface';

const loadFromlocalStorage = (): Character[] => {
    const data = localStorage.getItem('characters');
    
    return data ? JSON.parse(data) : [];

}

@Injectable({providedIn: 'root'})
export class DragonballService {
    
    characters = signal<Character[]>(loadFromlocalStorage());

    saveToLocalStorage = effect(() => {
        localStorage.setItem('characters', JSON.stringify(this.characters()));
    });

    addCharacter(character: Character) {
        this.characters.update(chars => [...chars, character]);
    }
    
}