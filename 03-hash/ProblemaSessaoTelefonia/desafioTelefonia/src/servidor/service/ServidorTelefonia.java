package servidor.service;

import java.rmi.AlreadyBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import servidor.model.TabelaHash;

public class ServidorTelefonia implements AutoCloseable {

    public static final int PORTA_PADRAO = 1099;
    public static final int PORTA_SERVICO = 1100;
    public static final String NOME_SERVICO = "ServicoTelefonia";

    private final TabelaHash tabela;
    private Registry registro;
    private ServicoTelefoniaImpl servico;

    public ServidorTelefonia(TabelaHash tabela) {
        this.tabela = tabela;
    }

    public synchronized void iniciar() throws RemoteException {
        if (servico != null) {
            return;
        }

        registro = LocateRegistry.createRegistry(PORTA_PADRAO);
        servico = new ServicoTelefoniaImpl(tabela, PORTA_SERVICO);
        try {
            registro.bind(NOME_SERVICO, servico);
        } catch (AlreadyBoundException e) {
            throw new RemoteException("O serviço RMI já está registrado.", e);
        }
    }

    @Override
    public synchronized void close() {
        if (servico != null) {
            try {
                registro.unbind(NOME_SERVICO);
            } catch (Exception e) {
                System.err.println("Erro ao remover serviço RMI: " + e.getMessage());
            }
            try {
                UnicastRemoteObject.unexportObject(servico, true);
            } catch (Exception e) {
                System.err.println("Erro ao encerrar serviço RMI: " + e.getMessage());
            }
            servico = null;
        }
        if (registro != null) {
            try {
                UnicastRemoteObject.unexportObject(registro, true);
            } catch (Exception e) {
                System.err.println("Erro ao encerrar registro RMI: " + e.getMessage());
            }
            registro = null;
        }
    }
}
