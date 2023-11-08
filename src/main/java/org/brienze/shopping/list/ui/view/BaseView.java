package org.brienze.shopping.list.ui.view;

import org.brienze.shopping.list.ui.action.FrameDragListener;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class BaseView {
    private JFrame frame;
    private JPanel startPanelLeft;
    private JPanel startPanelRight;
    private JLabel closeButton;
    private JLabel minimizeButton;
    private JPanel homePanel;
    private JLabel lblHome;
    private JLabel homeIcon;

    public BaseView() {
        frame = new JFrame();
        frame.setTitle("Shopping List");
        frame.setResizable(true);
        frame.setBounds(200, 200, 800, 550);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.getContentPane().setLayout(null);
        frame.setUndecorated(true);

        startPanelLeft = new JPanel();
        startPanelLeft.setBounds(0, 0, 250, 550);
        startPanelLeft.setBackground(new Color(0, 51, 153));
        startPanelLeft.setLayout(null);
        frame.getContentPane().add(startPanelLeft);

        homePanel = new JPanel();
        homePanel.setBackground(new Color(0, 102, 204));
        homePanel.setBounds(0, 100, 250, 49);
        homePanel.setLayout(null);
        startPanelLeft.add(homePanel);

        lblHome = new JLabel("Home");
        lblHome.setForeground(new Color(255, 255, 255));
        lblHome.setFont(new Font("Meiryo", Font.BOLD, 14));
        lblHome.setBounds(85, 11, 111, 27);
        homePanel.add(lblHome);

        homeIcon = new JLabel("");
        homeIcon.setIcon(new ImageIcon("src/main/resources/icons/home.png"));
        homeIcon.setBounds(28, 6, 65, 32);
        homePanel.add(homeIcon);

        startPanelRight = new JPanel();
        startPanelRight.setBounds(250, 0, 550, 550);
        startPanelRight.setBackground(Color.WHITE);
        startPanelRight.setLayout(null);
        frame.getContentPane().add(startPanelRight);

        closeButton = new JLabel("");
        closeButton.setIcon(new ImageIcon("src/main/resources/icons/close.png"));
        closeButton.setBounds(530, 5, 20, 14);
        startPanelRight.add(closeButton);

        minimizeButton = new JLabel("");
        minimizeButton.setIcon(new ImageIcon("src/main/resources/icons/minimize.png"));
        minimizeButton.setBounds(512, 5, 20, 14);
        startPanelRight.add(minimizeButton);

        addActions();
    }

    public void show() {
        frame.setVisible(true);
    }

    private void addActions() {
        FrameDragListener frameDragListener = new FrameDragListener(frame);
        frame.addMouseListener(frameDragListener);
        frame.addMouseMotionListener(frameDragListener);

        homePanel.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent e) {
                homePanel.setBackground(new Color(0, 153, 255));
                homeIcon.setIcon(new ImageIcon("src/main/resources/icons/home_selected.png"));
                lblHome.setFont(new Font("Meiryo", Font.BOLD, 16));
            }

            @Override
            public void mouseExited(MouseEvent e) {
                homePanel.setBackground(new Color(0, 102, 204));
                homeIcon.setIcon(new ImageIcon("src/main/resources/icons/home.png"));
                lblHome.setFont(new Font("Meiryo", Font.BOLD, 14));
            }

            @Override
            public void mouseClicked(MouseEvent e) {
//                HomeView homeView = new HomeView(user);
//                Point point = frame.getLocation().getLocation();
//                homeView.show(point);
//                frame.dispose();
            }
        });


        closeButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent e) {
                closeButton.setIcon(new ImageIcon("src/main/resources/icons/close_selected.png"));
            }

            @Override
            public void mouseExited(MouseEvent e) {
                closeButton.setIcon(new ImageIcon("src/main/resources/icons/close.png"));
            }

            @Override
            public void mouseClicked(MouseEvent e) {
                while (true) {
                    System.exit(0);
                }
            }
        });

        minimizeButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseEntered(MouseEvent e) {
                minimizeButton.setIcon(new ImageIcon("src/main/resources/icons/minimize_selected.png"));
            }

            @Override
            public void mouseExited(MouseEvent e) {
                minimizeButton.setIcon(new ImageIcon("src/main/resources/icons/minimize.png"));
            }

            @Override
            public void mouseClicked(MouseEvent e) {
                frame.setExtendedState(JFrame.ICONIFIED);
            }
        });

    }
}
