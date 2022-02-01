import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  //TODO: the screen size will adjust down to the smallest size it can accomodate but i can for the life of me 
  // just not get it show the content after dropdown the menu and collapse its just gone Example works so im missing something
  // But it works for now so im just going with it

  //Login element of this part should probably be a popup of some kind so that.

  constructor() { }

  ngOnInit(): void {
  }
  
  Login(){
    
  }
}
