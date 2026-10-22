package cliente.service;

import java.rmi.Naming;
import java.rmi.RemoteException;
import servidor.service.ServicoTelefonia;
import servidor.service.ServidorTelefonia;

public class ClienteTelefonia {

    private final ServicoTelefonia servico;

    public ClienteTelefonia(String host, int porta) throws RemoteException {
        try {
            servico = (ServicoTelefonia) Naming.lookup(
                    "//" + host + ":" + porta + "/" + ServidorTelefonia.NOME_SERVICO);
        } catch (Exception e) {
            throw new RemoteException("Não foi possível localizar o serviço RMI.", e);
        }
    }

    public String consultar(String numeroCelular) throws RemoteException {
        String numero = numeroCelular == null ? "" : numeroCelular.trim();
        if (numero.isEmpty()) {
            throw new IllegalArgumentException("Informe um número de celular.");
        }
        return servico.pesquisar(numero);
    }
}
