import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: 'nav.component.html',
  styleUrls: ['nav.component.css']
})
export class NavComponent implements OnInit {
  backdrop;
  sideDrawer;
  menuToggle;


  ngOnInit() {
    this.backdrop = document.querySelector('.backdrop');
    this.sideDrawer = document.querySelector('.mobile-nav');
    this.menuToggle = document.querySelector('#side-menu-toggle');
  }

  backdropClickHandler() {
    this.backdrop.style.display = 'none';
    this.sideDrawer.classList.remove('open');
  }

  menuToggleClickHandler() {
    this.backdrop.style.display = 'block';
    this.sideDrawer.classList.add('open');
  }
}
