import {  Component } from '@angular/core';
import SideMenuOptionsComponent from '../side-menu-options/side-menu-options.component';
import SideMenuHeaderComponent from '../side-menu-header/side-menu-header.component';

@Component({
  selector: 'gifs-side-menu',
  imports: [ SideMenuHeaderComponent, SideMenuOptionsComponent ],
  templateUrl: './side-menu.component.html'
})
export default class SideMenuComponent {}
