import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupUpdaterComponent } from './group-updater.component';

describe('GroupUpdaterComponent', () => {
  let component: GroupUpdaterComponent;
  let fixture: ComponentFixture<GroupUpdaterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupUpdaterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupUpdaterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
