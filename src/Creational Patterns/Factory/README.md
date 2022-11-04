# Factory Pattern
## **Problem:** *Komplizierte Instanzen sollen erstellt werden.*

## **Lösung:**
- Die Instanziierung wird in eine Factory ausgelagert.
- abstract Factory class mit Factory Method ist notwendig.
- Die Factory class hat eine Methode "Construct" zur instanziierung der Objecte.
- Konkrete Factories sollen Factory Method fertig implementieren.