export class AdGuardList {
  private _elements: Map<string, string>;

  constructor() {
    this._elements = new Map<string, string>();
  }

  public add(rule: string, origin: string[]): boolean {
    if (this._elements.has(rule)) {
      return false;
    }

    this._elements.set(rule, origin.join(';'));
  }

  public adds(rules: string[], origin: string[]): void {
    for (const rule of rules) {
      this.add(rule, origin);
    }
  }

  public export(): Map<string, string> {
    return this._elements;
  }
}
