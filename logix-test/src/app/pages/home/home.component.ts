import { Component, OnInit } from '@angular/core';
import { DATA } from '@app/_constant'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public filmList = DATA
  public numLike: number = 0

  public isLike: boolean = false
  public isDisLike: boolean = false

  constructor() { }

  ngOnInit() {
  }

  public onLike(e: number) {
    if (e) {
      this.numLike++
    }
  }

}
