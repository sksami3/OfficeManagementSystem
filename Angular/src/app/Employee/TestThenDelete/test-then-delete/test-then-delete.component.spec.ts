import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestThenDeleteComponent } from './test-then-delete.component';

describe('TestThenDeleteComponent', () => {
  let component: TestThenDeleteComponent;
  let fixture: ComponentFixture<TestThenDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestThenDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestThenDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
