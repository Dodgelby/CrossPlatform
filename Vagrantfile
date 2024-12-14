# -*- mode: ruby -*-
# vi: set ft=ruby :

# Define the host IP addresses
hosts = {
  "ubuntu" => "192.168.56.56",
  "windows" => "192.168.56.59"
   #"mac" => "192.168.56.11"
}

Vagrant.configure("2") do |config|
  # Common network configuration
  config.vm.network "public_network", bridge: "default"
  
  # Ubuntu Machine Configuration
  config.vm.define "ubuntu" do |ubuntu|
    ubuntu.vm.box = "bento/ubuntu-22.04"
    ubuntu.vm.hostname = "ubuntu-vm"
	# Port forwarding for your specific application
    ubuntu.vm.network "forwarded_port", guest: 7255, host: 7255
    # Try both private and public network
    ubuntu.vm.network "private_network", ip: hosts["ubuntu"]
    ubuntu.vm.provider "virtualbox" do |v|
      v.name = "Ubuntu Danylo Poliarush"
	  v.gui = true
      v.memory = "6000"
      v.cpus = 10
      # Enable all network adapter types
      v.customize ["modifyvm", :id, "--nictype1", "82540EM"]
      v.customize ["modifyvm", :id, "--nictype2", "82540EM"]
    end
    ubuntu.vm.synced_folder ".", "/home/vagrant/project"
    ubuntu.vm.provision "shell", path: "provision-ubuntu.sh"
  end

  # Windows Machine Configuration
  config.vm.define "windows" do |windows|
    windows.vm.box = "gusztavvargadr/windows-10"
    windows.vm.hostname = "windows-vm"
    # Try both private and public network
    windows.vm.network "private_network", ip: hosts["windows"]
    windows.vm.provider "virtualbox" do |v|
      v.name = "Windows Danylo Poliarush"
      v.memory = "6096"
      v.cpus = 8
      # Enable all network adapter types
      v.customize ["modifyvm", :id, "--nictype1", "82540EM"]
      v.customize ["modifyvm", :id, "--nictype2", "82540EM"]
    end
    windows.vm.synced_folder ".", "C:/project"
    windows.vm.provision "shell", path: "provision-windows.sh"
  end

  # Mac Machine Configuration (commented out)
  #config.vm.define "mac" do |mac|
    #mac.vm.box = "ramsey/macos-catalina"
    #mac.vm.hostname = "mac-vm"
    #mac.vm.network "private_network", ip: hosts["mac"]
    #mac.vm.provider "virtualbox" do |v|
      #v.name = "Mac Danylo Poliarush"
      #v.memory = "4096"
      #v.cpus = 2
      #v.customize ["modifyvm", :id, "--nictype1", "82540EM"]
      #v.customize ["modifyvm", :id, "--nictype2", "82540EM"]
    #end
    #mac.vm.synced_folder ".", "/Users/vagrant/project"
    #mac.vm.provision "shell", path: "provision-mac.sh"
  #end
end
