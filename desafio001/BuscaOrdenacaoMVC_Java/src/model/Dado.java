package model;

/**
 * Classe que representa um dado, contendo um valor do tipo String
 */
public class Dado {
    private String valor;

    /**
     * construtor da classe Dado
     * @param valor valor do dado a ser criado
     */
    public Dado(String valor) {
        this.valor = valor;
    }

    public String getValor() {
        return valor;
    }

    public void setValor(String valor) {
        this.valor = valor;
    }

    @Override
    public String toString() {
        return valor;
    }
}
