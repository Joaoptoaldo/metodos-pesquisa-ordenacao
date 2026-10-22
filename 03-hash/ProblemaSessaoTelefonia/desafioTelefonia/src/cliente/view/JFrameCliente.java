package cliente.view;

import cliente.service.ClienteTelefonia;
import java.awt.BorderLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.io.IOException;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import servidor.service.ServidorTelefonia;

/**
 * Interface do cliente que consulta o servidor de telefonia.
 */
public class JFrameCliente extends JFrame {

    private final JTextField campoHost = new JTextField("localhost", 12);
    private final JTextField campoPorta = new JTextField(
            String.valueOf(ServidorTelefonia.PORTA_PADRAO), 6);
    private final JTextField campoNumero = new JTextField(20);
    private final JTextArea areaResultado = new JTextArea(8, 45);

    public JFrameCliente() {
        super("Cliente de Sessões em Telefonia");
        criarComponentes();
    }

    private void criarComponentes() {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout(8, 8));

        JPanelConsulta painel = new JPanelConsulta();
        add(painel, BorderLayout.NORTH);

        areaResultado.setEditable(false);
        areaResultado.setLineWrap(true);
        areaResultado.setWrapStyleWord(true);
        add(new JScrollPane(areaResultado), BorderLayout.CENTER);

        pack();
        setLocationRelativeTo(null);
        campoNumero.requestFocusInWindow();
    }

    private class JPanelConsulta extends javax.swing.JPanel {

        JPanelConsulta() {
            setLayout(new GridBagLayout());
            GridBagConstraints c = new GridBagConstraints();
            c.insets = new Insets(4, 4, 4, 4);
            c.anchor = GridBagConstraints.WEST;

            c.gridx = 0;
            c.gridy = 0;
            add(new JLabel("Servidor:"), c);
            c.gridx = 1;
            add(campoHost, c);
            c.gridx = 2;
            add(new JLabel("Porta:"), c);
            c.gridx = 3;
            add(campoPorta, c);

            c.gridx = 0;
            c.gridy = 1;
            add(new JLabel("Número de celular:"), c);
            c.gridx = 1;
            c.gridwidth = 2;
            add(campoNumero, c);
            c.gridx = 3;
            c.gridwidth = 1;
            JButton pesquisar = new JButton("Pesquisar");
            pesquisar.addActionListener(event -> pesquisar());
            add(pesquisar, c);
            campoNumero.addActionListener(event -> pesquisar());
        }
    }

    private void pesquisar() {
        try {
            int porta = Integer.parseInt(campoPorta.getText().trim());
            ClienteTelefonia cliente = new ClienteTelefonia(campoHost.getText().trim(), porta);
            String dados = cliente.consultar(campoNumero.getText());
            areaResultado.setText(dados == null
                    ? "Número de celular não encontrado."
                    : dados);
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(this, "A porta deve ser um número inteiro.");
        } catch (IllegalArgumentException e) {
            JOptionPane.showMessageDialog(this, e.getMessage());
        } catch (IOException e) {
            JOptionPane.showMessageDialog(this,
                    "Não foi possível conectar ao servidor: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        java.awt.EventQueue.invokeLater(() -> new JFrameCliente().setVisible(true));
    }
}
