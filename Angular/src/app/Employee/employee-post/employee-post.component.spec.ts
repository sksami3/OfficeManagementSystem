import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeePostComponent } from './employee-post.component';

describe('EmployeePostComponent', () => {
  let component: EmployeePostComponent;
  let fixture: ComponentFixture<EmployeePostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeePostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeePostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
