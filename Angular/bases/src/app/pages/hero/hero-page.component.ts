import { UpperCasePipe } from "@angular/common";
import { ChangeDetectionStrategy, Component, computed, signal } from "@angular/core";


@Component({  selector: "app-hero-page",
  templateUrl: "./hero-page.component.html",
  styleUrls: ["./hero-page.component.css"],
  imports: [UpperCasePipe],

   changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroPageComponent {  

  name = signal("Ironman");
  age  = signal(45);

  heroDescription = computed( () => `${this.name()} - ${this.age()}` );

  capitalizedName = computed( () => this.name().toUpperCase() );

  /*getHeroDescription(): string {
    return `${this.name()} - ${this.age()}`;
  }*/

  changeHero( ): void {
    this.name.set( 'Spiderman');
    this.age.set( 22 );
  }

  changeAge(): void {
    this.age.set( 60 );
  }

  resetForm(): void {
    this.name.set("Ironman");
    this.age.set(45);
  }
}